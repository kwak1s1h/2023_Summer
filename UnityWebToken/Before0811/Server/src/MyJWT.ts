import jwt from "jsonwebtoken";
import { UserVO } from "./Types";
import { NextFunction, Request, Response } from "express";

export const tokenChecker =async (req: Request, res: Response, next: NextFunction) => {
    let token = extractToken(req);
    if(token != undefined) {
        let decodedToken = decodeJWT(token);
        if(decodedToken != null) {
            let { email, xp: exp, name, id } = decodedToken as jwt.JwtPayload;
            req.user = { id, email, exp, name };
        }
        else req.user = null;
    }
    else req.user = null;
    
    next();
}

function extractToken(req: Request): string | undefined {
    const PREFIX = "Bearer";
    const auth = req.headers.authorization;
    const token = auth?.includes(PREFIX) ? auth.split(PREFIX)[1] : auth;
    return token;
}

export const createJWT = (userVO: UserVO): string => {
    const { id, email, name, exp: xp } = userVO;
    const token = jwt.sign({id, email, name, xp}, process.env.JWT_SECRET!, {
        expiresIn: "7 days",
        algorithm: "HS256",
    });

    return token;
}

export const decodeJWT = (token: string): string | jwt.JwtPayload | null => {
    try {
        console.log(token);
        const decodedToken = jwt.verify(token, process.env.JWT_SECRET!);
        return decodedToken;
    }
    catch(err) {
        return null;
    }
}