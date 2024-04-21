interface Doctor {
  firstName: string;
  lastName: string;
  imageUrl: string;
  speciality: Speciality;
  facebookLink: string | undefined;
  twitterLink: string | undefined;
  linkedinLink: string | undefined;
  pinterestLink: string | undefined;
}
interface Speciality {
  name: string;
  description: string;
}

export { Doctor };
