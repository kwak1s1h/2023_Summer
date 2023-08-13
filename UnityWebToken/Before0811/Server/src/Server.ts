import Express, { Application, Request, Response } from "express";
import nunjucks from "nunjucks"
import { lunchRouter } from "./LunchRouter";
import dotenv from "dotenv";
import { userRouter } from "./UserRouter";
import { tokenChecker } from "./MyJWT";
dotenv.config();

const app: Application = Express();

app.use(Express.json());
app.use(Express.urlencoded({extended: true}));
app.set("view engine", "njk");
nunjucks.configure("views", {express: app, watch: true});

app.use(tokenChecker);

app.use(lunchRouter);
app.use('/user', userRouter);

app.listen(3000, () => {
    console.log(`http://localhost:${3000}/lunch`);
});