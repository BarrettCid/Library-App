export interface IRegister {
    firstName: string;
    lastName: string;
    email: string;
    password: string;
    role: string;
}


export class Register implements IRegister {
    firstName!: string;
    lastName!: string;
    email!: string;
    password!: string;
    role!:string;
}