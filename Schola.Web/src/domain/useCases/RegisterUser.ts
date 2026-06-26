import type { UserRepository } from "../../infrastructure/repositories/UserRepository";




export class RegisterUser {
  private repo: UserRepository;

  constructor(repo: UserRepository) {
    this.repo = repo;
  }

 async execute(id: string) {
    return await this.repo.getUser(id);
  }
}