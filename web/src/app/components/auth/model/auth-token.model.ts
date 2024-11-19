export class Token {
  accessToken!: string;
  refreshToken!: string;
  resetPasswordToken: string | null = null;
  expiresIn!: number;
  tokenType!: string;
}
