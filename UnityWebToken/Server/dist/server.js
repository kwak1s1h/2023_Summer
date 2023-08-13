"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const express_1 = __importDefault(require("express"));
//익스프레스 어플리케이션 이건 웹서버
let app = (0, express_1.default)();
//Get, Post, Put, Delete  => Method
// CRUD -> Create, Read, Update, Delete
// Application단에서 CRUD를 구현했어 API
// URI Get (Read), Post(Create), Put(Update), Delete
// RestFul API
app.get("/lunch", (req, res) => {
    res.json({ id: 1, msg: "안녕하세요" });
});
app.listen(3000, () => {
    console.log(`
        #############################################
        #  Server is starting on 3000 port          #
        #  http://localhost:3000                    #
        #############################################
        `);
});
