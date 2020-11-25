export class UserProfile {
    id: number;
    dateCreated: Date;
    role: string;
    name: string;
    surname: string;
    position: string;
    birthDate: Date;
    phone: string;
    city: string;
    websiteLink: string;
    facebookLink: string;
    twitterLink: string;
    profileImageUrl: string;
    login: string;
    password: string;
    email: string;
    isBanned: boolean;

    constructor() {
        this.id = 0;
        this.dateCreated = new Date();
        this.name = '';
        this.surname = '';
        this.position = '';
        this.birthDate = new Date();
        this.phone = '';
        this.city = '';
        this.websiteLink = '';
        this.facebookLink = '';
        this.twitterLink = '';
        this.profileImageUrl = '';
        this.login = '';
        this.password = '';
        this.email = '';
        this.isBanned = false;
    }
}