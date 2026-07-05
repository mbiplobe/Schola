// src/domain/validators/sectionSchema.ts

import { z } from "zod";

export const sectionSchema = z.object({
    name: z
        .string()
        .trim()
        .min(1, "Section name is required")
        .max(50, "Section name cannot exceed 50 characters")
});

export type SectionFormData = z.infer<
    typeof sectionSchema
>;