// modules/section/domain/repositories/ISectionRepository.ts

import type { SectionDto } from "../../infrastructure/dto/SectionDto";



export interface ISectionRepository {
    getAll(): Promise<SectionDto[]>;
    create(name: string): Promise<void>;
    update(id: number, name: string): Promise<void>;
    delete(id: number): Promise<void>;
}