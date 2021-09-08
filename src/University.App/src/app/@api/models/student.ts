import { Book, Cellphone } from "@api";

export type Student = {
    studentId: string,
    firstname: string,
    lastname: string,
    age: number,
    book?: Book,
    cellphone?: Cellphone
};
