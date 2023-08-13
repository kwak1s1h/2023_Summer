import { Router } from "express";
import { MessageType, SlotVO } from "./Types";
import { Pool } from "./DB";
import { ResultSetHeader, RowDataPacket } from "mysql2";
import { RandomTable } from "./RandomTable";

export const slotRouter = Router();

slotRouter.get("/slot", async (req, res) => {
    if(req.user == null)
    {
        res.json({type: MessageType.ERROR, message: "로그인이 필요합니다."});
        return;
    }
    let used: number = Number.parseInt(req.query.used as string);
    let [rows, cols]: [RowDataPacket[], any] = await Pool.query("SELECT money FROM users WHERE id = ?", [req.user.id]);
    if(rows.length <= 0) 
    {
        res.json({type: MessageType.ERROR, message: "정보를 가져올 수 없습니다."});
        return;
    }
    let have = rows[0].money;
    if(used > have)
    {
        res.json({type: MessageType.ERROR, message: "돈이 부족합니다."});
        return;
    }

    let sql = "UPDATE users SET money = ? WHERE id = ?";
    let [result, col]: [ResultSetHeader, any] = await Pool.execute(sql, [have - used, req.user.id]);
    console.log(`${req.user.name}님이 ${used}원 결제함. 남은돈: ${have - used}`);

    let slotVO: SlotVO = { money: have - used, score: 0, success: false };
    slotVO.money = have - used;

    let {percent, score} = RandomTable[used];
    let rand = Math.random() * 100;
    if(rand < percent)
    {
        slotVO.success = true;
        slotVO.score = score;
    }

    res.json({type: MessageType.SUCCESS, message: JSON.stringify(slotVO)});
})