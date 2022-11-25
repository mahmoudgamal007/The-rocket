export interface IUser {
    userId: string,
    accountId: number,
    userName: string,
    brandName?: string,
    firstName: string,
    lastName: string,
    jwtToken: string,
    accountType: string
}