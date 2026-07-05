// modules/section/domain/entities/Section.ts

// domain/entities/Section.ts

export class SectionEntity {
    constructor(
        public readonly id: number,
        public readonly name: string,
        public readonly createdBy: string
    ) {
        if (!name.trim()) {
            throw new Error(
                "Section name is required."
            );
        }

        if (name.length > 100) {
            throw new Error(
                "Section name cannot exceed 50 characters."
            );
        }
    }
}