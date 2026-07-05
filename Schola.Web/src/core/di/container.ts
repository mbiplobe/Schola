import { SectionUseCase } from "../../domain/useCases/SectionUseCase";
import { SectionRepository } from "../../infrastructure/repositories/SectionRepository";



const objSectionRepository = new SectionRepository();

export const objSectionUseCase = new SectionUseCase(objSectionRepository);