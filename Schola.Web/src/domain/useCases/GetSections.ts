// modules/section/domain/usecases/GetSections.ts

import { SectionRepository } from "../../infrastructure/repositories/SectionRepository";

export const getSections = async () => {
    const repository = new SectionRepository();

    return await repository.getAll();
};