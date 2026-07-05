import { SectionEntity } from "../entities/SectionEntity";
import type { ISectionRepository } from "../repositories/ISectionRepository";

export class SectionUseCase {
    constructor(
        private readonly repository: ISectionRepository
    ) {}

    async getAll() {
        return await this.repository.getAll();
    }

    async create(name: string) {
        const section = new SectionEntity(
            0,
            name,
            "system"
        );

        return await this.repository.create(section);
    }

    async update(
        id: number,
        name: string
    ) {
        const section = new SectionEntity(
            id,
            name,
            "system"
        );

        return await this.repository.update(section);
    }

    async delete(id: number) {
        return await this.repository.delete(id);
    }
}