
import { useEffect, useState } from "react";
import type { SectionDto } from "../../infrastructure/dto/SectionDto";
import { getSections } from "../../domain/useCases/GetSections";

export const useSections = () => {
    const [sections, setSections] = useState<SectionDto[]>([]);

    const load = async () => {
        const data = await getSections();
        setSections(data);
    };

    useEffect(() => {
        // eslint-disable-next-line react-hooks/set-state-in-effect
        load();
    }, []);

    return {
        sections,
        reload: load
    };
};


