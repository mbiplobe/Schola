import { useState } from "react";
import {
    Plus,
    Pencil,
    Trash2,
    FolderOpen
} from "lucide-react";

import { useSections } from "../hooks/useSections";
import { SectionRepository } from "../../infrastructure/repositories/SectionRepository";
import type { SectionDto } from "../../infrastructure/dto/SectionDto";

export default function SectionPage() {
    const { sections, reload } = useSections();

    const repository = new SectionRepository();

    const [name, setName] = useState("");
    const [editingId, setEditingId] = useState<number | null>(null);

    const handleSubmit = async () => {
        if (!name.trim()) {
            return;
        }

        try {
            if (editingId) {
                await repository.update(editingId, name);
            } else {
                await repository.create(name);
            }

            setName("");
            setEditingId(null);

            await reload();
        } catch (error) {
            console.error(error);
        }
    };

    const handleEdit = (section: SectionDto) => {
        setEditingId(section.id);
        setName(section.name);
    };

    const handleDelete = async (id: number) => {
        if (!window.confirm("Delete this section?")) {
            return;
        }

        try {
            await repository.delete(id);
            await reload();
        } catch (error) {
            console.error(error);
        }
    };

    return (
        <div className="space-y-6">
            <div>
                <h1 className="text-3xl font-bold text-slate-800">
                    Sections
                </h1>

                <p className="mt-1 text-slate-500">
                    Manage academic sections.
                </p>
            </div>

            <div className="rounded-2xl bg-white p-6 shadow-sm">
                <div className="mb-5 flex items-center gap-2">
                    <Plus size={20} />
                    <h2 className="text-xl font-semibold">
                        {editingId
                            ? "Update Section"
                            : "Add New Section"}
                    </h2>
                </div>

                <div className="flex flex-col gap-4 md:flex-row">
                    <input
                        type="text"
                        value={name}
                        onChange={(e) =>
                            setName(e.target.value)
                        }
                        placeholder="Enter section name"
                        className="flex-1 rounded-xl border border-slate-300 px-4 py-3 outline-none focus:border-blue-500"
                    />

                    <button
                        onClick={handleSubmit}
                        className="rounded-xl bg-blue-600 px-6 py-3 font-medium text-white transition hover:bg-blue-700"
                    >
                        {editingId
                            ? "Update"
                            : "Save"}
                    </button>
                </div>
            </div>

            <div className="rounded-2xl bg-white shadow-sm">
                <div className="border-b p-6">
                    <div className="flex items-center gap-2">
                        <FolderOpen size={20} />

                        <h2 className="text-xl font-semibold">
                            Section List
                        </h2>
                    </div>
                </div>

                <div className="overflow-x-auto">
                    <table className="w-full">
                        <thead>
                            <tr className="bg-slate-50">
                                <th className="px-6 py-4 text-left">
                                    ID
                                </th>

                                <th className="px-6 py-4 text-left">
                                    Name
                                </th>

                                <th className="px-6 py-4 text-center">
                                    Actions
                                </th>
                            </tr>
                        </thead>

                        <tbody>
                            {sections.length === 0 ? (
                                <tr>
                                    <td
                                        colSpan={3}
                                        className="py-10 text-center text-slate-500"
                                    >
                                        No sections found.
                                    </td>
                                </tr>
                            ) : (
                                sections.map((section) => (
                                    <tr
                                        key={section.id}
                                        className="border-t hover:bg-slate-50"
                                    >
                                        <td className="px-6 py-4">
                                            {section.id}
                                        </td>

                                        <td className="px-6 py-4 font-medium">
                                            {section.name}
                                        </td>

                                        <td className="px-6 py-4">
                                            <div className="flex justify-center gap-2">
                                                <button
                                                    onClick={() =>
                                                        handleEdit(
                                                            section
                                                        )
                                                    }
                                                    className="rounded-lg bg-amber-500 p-2 text-white hover:bg-amber-600"
                                                >
                                                    <Pencil size={16} />
                                                </button>

                                                <button
                                                    onClick={() =>
                                                        handleDelete(
                                                            section.id
                                                        )
                                                    }
                                                    className="rounded-lg bg-red-500 p-2 text-white hover:bg-red-600"
                                                >
                                                    <Trash2 size={16} />
                                                </button>
                                            </div>
                                        </td>
                                    </tr>
                                ))
                            )}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}