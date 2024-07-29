export interface IIdentityLogin {
    tokenType: string;
    accessToken: string;
    expiresIn: number;
    refreshnToken: string;
}

export class IdentityLogin implements IIdentityLogin {
    tokenType!: string;
    accessToken!: string;
    expiresIn!: number;
    refreshnToken!: string;
}