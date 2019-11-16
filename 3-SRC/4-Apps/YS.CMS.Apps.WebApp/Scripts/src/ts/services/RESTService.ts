import { Http } from './HTTP';
import { IHttpResponse } from './../interface/IHttpResponse';

const headers = new Headers();
headers.append('Accept', 'application/json');
headers.append('Content-Type', 'application/json');

export const Get = async <T>(
    path: string,
    args: RequestInit = { method: "get" }): Promise<IHttpResponse<T>> => {
        return await Http<T>(new Request(path, args));
};

export const Post = async <T>(
    path: string,
    body: any,
    args: RequestInit = { method: "post", headers: headers,  body: JSON.stringify(body) }): Promise<IHttpResponse<T>> => {
        return await Http<T>(new Request(path, args));
};

export const Put = async <T>(
    path: string,
    body: any,
    args: RequestInit = { method: "put", body: JSON.stringify(body) }): Promise<IHttpResponse<T>> => {
        return await Http<T>(new Request(path, args));
};

export const Delete = async <T>(
    path: string,
    body: any,
    args: RequestInit = { method: "delete", body: JSON.stringify(body) }): Promise<IHttpResponse<T>> => {
        return await Http<T>(new Request(path, args));
};