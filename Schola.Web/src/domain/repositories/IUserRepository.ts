import type { User } from "../entities/User";

export interface IUserRepository {
  getUser(id: string): Promise<User>;
}