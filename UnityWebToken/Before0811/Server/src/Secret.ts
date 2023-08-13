import mysql from "mysql2";
import dotenv from "dotenv";
dotenv.config();

export const DBConfig: mysql.PoolOptions = {
    user: "yy_40103",
    password: process.env.DB_PW,
    database: "yy_40103",
    host: "gondr99.iptime.org",
}