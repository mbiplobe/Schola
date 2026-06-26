import type { User } from "../../domain/entities/User";
import type { IUserRepository } from "../../domain/repositories/IUserRepository";
import axios from "../api/axios";
import type { RegisterUserDto } from "../dto/RegisterUserDto";
import { mapUserDtoToUser } from "../mappers/UserMapper";

export class UserRepository implements IUserRepository {
  async getUser(id: string): Promise<User> {
    const response = await axios.get<RegisterUserDto>(`/users/${id}`);
    return mapUserDtoToUser(response.data);
  }
}


