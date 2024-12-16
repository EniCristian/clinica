interface Doctor {
  id: string;
  specialityId: string;
  consultationPrice: number;
  firstName: string;
  lastName: string;
  description: string;
  email: string;
  phoneNumber: string;
  imageUrl: string;
  speciality: Speciality;
  facebookLink: string | undefined;
  twitterLink: string | undefined;
  linkedinLink: string | undefined;
  pinterestLink: string | undefined;
}
interface Speciality {
  id: string;
  name: string;
  description: string;
}

export { Doctor };
