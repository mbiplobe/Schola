import type { ClassDto } from "../../infrastructure/dto/ClassDto";
import type { ClassEntity } from "../entities/ClassEntity";

export interface IClassRepository {
    getAll(): Promise<ClassDto[]>;
    create(section : ClassEntity): Promise<boolean>;
    update(section: ClassEntity): Promise<boolean>;
    delete(id: number): Promise<boolean>;
}