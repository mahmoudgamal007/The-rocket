import { IAddress } from "./address";
import { IAdmin } from "./admin";
import { IBuyer } from "./Ibuyer";
import { ILocation } from "./location";
import { IPhoneNumber } from "./phoneNumber";
import { ISeller } from "./Iseller";

export interface IAppUser {
    id?: string;
    userName?: string;
    email?: string;
    password?: string;
    confirmPassword?: string;
    seller?: ISeller;
    buyer?: IBuyer;
    admin?: IAdmin;
    phoneNumbers?: IPhoneNumber[];
    addresses?: IAddress[];
    locations?: ILocation[];
    accountType?: number;
}