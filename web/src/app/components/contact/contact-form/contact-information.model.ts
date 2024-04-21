interface ContactInformation {
  address: ContactAddress;
  schedule: string;
  phoneNumber: string;
  email: string;
  emailMessage: string;
}
interface ContactAddress {
  country: string;
  city: string;
  street: string;
}

export { ContactInformation, ContactAddress };
