import e, { Router } from "express";
import { Pool } from "./DB";
import { MessageType, ResponseMSG, UserVO } from "./Types";
import { ResultSetHeader, RowDataPacket } from "mysql2/promise";
import { createJWT } from "./MyJWT";

export const userRouter = Router();

userRouter.get('/', async (req, res) => {
    let resMsg: ResponseMSG = { type: MessageType.ERROR, message: "로그인이 필요합니다."};
    if(req.user != null) {
        console.log(req.user);
        resMsg.type = MessageType.SUCCESS;
        resMsg.message = JSON.stringify(req.user);
    }
    res.json(resMsg);
})

userRouter.get('/login', async (req, res) => {

});

userRouter.post('/login', async (req, res) => {
    let { email: inputEmail, password } = req.body;
    const sql = 'SELECT * FROM users WHERE email = ? AND password = PASSWORD(?)';
    let [rows, col]: [RowDataPacket[], any] = await Pool.query(sql, [inputEmail, password]);

    if(rows.length == 0) {
        res.json({type: MessageType.ERROR, message: "아이디 또는 비밀번호 일치하지 않음."});
        return;
    }

    let { id, email, name, exp } = rows[0];
    let user: UserVO = { id, email, name, exp };
    let token = createJWT(user);
    let resMsg: ResponseMSG = { type: MessageType.SUCCESS, message: JSON.stringify({token, user}) };
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