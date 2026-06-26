import type { User } from "../../domain/entities/User";
import type { RegisterUserDto } from "../dto/RegisterUserDto";


export const mapUserDtoToUser = (dto: RegisterUserDto): User => ({
  name: dto.fullName,
  email: dto.email,
  mobile: dto.mobile,
  password: dto.password,
});