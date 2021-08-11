export class Personal {
    Tz:string;
    Name:string;
    Address:string;
    Phone:string;
    Email:string;
    constructor(Tz?:string,Name?:string,Address?:string,
        Phone?:string,Email?:string){
            this.Tz=Tz;
            this.Name=Name;
            this.Address=Address;
            this.Phone=Phone;
            this.Email=Email;
    }
}
