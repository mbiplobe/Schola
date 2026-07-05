
import api from "../../core/api/axios";
import type { ISectionRepository } from "../../domain/repositories/ISectionRepository";
import type { SectionDto } from "../dto/SectionDto";

export class SectionRepository implements ISectionRepository {
  async getAll(): Promise<SectionDto[]> {
       try {
        const response = await api.get<SectionDto[]>("section");
        return response.data;
    } catch (error) {
        console.error("Failed to get sections:", error);
        throw error;
    }
    }

    async create(name: string) {
        await api.post("section", {
            name,
            createdBy: "Admin"
        });
    }

    async update(id: number, name: string) {
        await api.put("section", {
            id,
            name,
            updatedBy: "Admin"
        });
    }

    async delete(id: number) {
        await api.delete("section", {
            data: { id }
        });
    }
}