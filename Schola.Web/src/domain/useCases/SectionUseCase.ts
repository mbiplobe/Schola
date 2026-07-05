import type { ISectionRepository } from "../repositories/ISectionRepository";

export class SectionUseCase {
    constructor(
        private readonly repository: ISectionRepository
    ) {}

    async getAll() {
        return await this.repository.getAll();
    }

    async create(name: string) {
        await this.repository.create(name);
    }

    async update(id: number, name: string) {
        await this.repository.update(id, name);
    }

    async delete(id: number) {
        await this.repository.delete(id);
    }
}