import { Personal } from './Personal';

export class PersonalWithType extends Personal {

    IdType: number;
    constructor(Tz?: string, Name?: string, Address?: string,
        Phone?: string, Email?: string, IdType?: number) {
        super(Tz, Name, Address, Phone, Email)
        this.IdType = IdType;
    }
}
