import e, { Router } from "express";
import { Pool } from "./DB";
import { MessageType, ResponseMSG } from "./Types";
import { ResultSetHeader } from "mysql2/promise";

export const userRouter = Router();

userRouter.get('/login', async (req, res) => {

});

userRouter.post('/login', async (req, res) => {
    let { email, password } = req.body;
    let resMsg: ResponseMSG = {type: MessageType.SUCCESS, message: JSON.stringify({email, password})}
    res.json(resMsg);
});

userRouter.get('/register', async (req, res) => {
    res.render('register');
});

userRouter.post('/register', async (req, res) => {
    let { email, password, passwordc, username } = req.body;
    if(email == "" || password == "" || username == "") {
        let msg: ResponseMSG = {type: MessageType.ERROR, message: "필수값이 누락되었습니다."};
        res.json(msg);
        return;
    }
    if(password != passwordc) {
        let msg: ResponseMSG = {type: MessageType.ERROR, message: "비밀번호 확인과 일치하지 않습니다."};
        res.json(msg);
        return;
    }
    const sql = 'INSERT INTO users(email, password, name) VALUES (?, PASSWORD(?), ?)';
    let [result, info]: [ResultSetHeader, any] = await Pool.execute(sql, [email, password, username]);
    if(result.affectedRows != 1) {
        let msg: ResponseMSG = {type: MessageType.ERROR, message: "데이터베이스 오류가 발생했습니다."};
        res.json(msg);
        return;
    }
    let msg: ResponseMSG = {type: MessageType.SUCCESS, message: "회원가입이 완료되었습니다."};
    res.json(msg);
});