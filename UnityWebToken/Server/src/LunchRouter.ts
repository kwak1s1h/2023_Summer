import { Router } from "express";
import iconv from "iconv-lite";
import axios from "axios";
import { CheerioAPI, load } from "cheerio";
import { Pool } from "./DB";
import { RowDataPacket } from "mysql2/promise";

export const lunchRouter = Router();

lunchRouter.get('/', (req, res) => res.redirect('/lunch'));

lunchRouter.get('/lunch', async (req, res) => {
    let date: string = getToday();
    if(req.query.date) date = req.query.date as string;

    let result = await getDataFromDB(date);
    if(result) {
        let data = result[0];
        let menus = JSON.parse(data.menu);
        res.render('lunch', {menus, date});
        return;
    }

    const host: string = "ggm.hs.kr";
    const url: string = `https://${host}/lunch.view?date=${date}`;

    let axiosRes = await axios({url, method: 'GET', responseType: "arraybuffer", });

    let data: Buffer = axiosRes.data;
    let decoded = iconv.decode(data, 'euc-kr');

    const $: CheerioAPI = load(decoded);
    let menus: string[] = $(".menuName > span").text().split('\n').map(s => s.replace(/[0-9]+\./g, '')).filter(s => s != "");
    const json = {date, menus};
    res.render("lunch", json);

    if(menus.length > 0)
    await Pool.execute("INSERT INTO lunch(date, menu) VALUES(?, ?)", [date, JSON.stringify(menus)]);
});

async function getDataFromDB(date: string): Promise<RowDataPacket[] | null> {
    const sql = 'SELECT * FROM lunch WHERE date = ?';
    let [rows, fieldData]: [RowDataPacket[], any] = await Pool.query(sql, [date]);
    return rows.length > 0 ? rows : null;
}

function getToday(){
    var date = new Date();
    var year = date.getFullYear();
    var month = ("0" + (1 + date.getMonth())).slice(-2);
    var day = ("0" + date.getDate()).slice(-2);

    return year + month + day;
}