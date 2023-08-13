import express, { Application, Request, Response } from "express";
import nunjucks from 'nunjucks';

//미들웨어 가져오기
import { tokenChecker } from "./MyJWT";
//라우터 가져오기
import { lunchRouter } from "./LunchRouter";
import { userRouter } from "./UserRouter";
import { invenRouter } from "./InventoryRouter";
import { slotRouter } from "./SlotRouter";


//익스프레스 어플리케이션 이건 웹서버
let app : Application = express();

app.set("view engine", "njk");
nunjucks.configure("views", {express:app, watch:true});

app.use(express.json()); //post로 들어오는 데이터들을 json 형태로 파싱해주겠다.
app.use(express.urlencoded({extended:true}));

app.use(tokenChecker); //토큰을 체크한다.

app.use(slotRouter);
app.use(invenRouter);
//점심관련 라우터
app.use(lunchRouter);
//유저관련 라우터
app.use(userRouter);

app.listen(3000, ()=> {
    console.log(
        `
        #############################################
        #  Server is starting on 3000 port          #
        #  http://localhost:3000                    #
        #############################################
        `
    )
});

