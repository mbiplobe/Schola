import { useState } from "react";
import {
    Plus,
    Pencil,
    Trash2,
    FolderOpen
} from "lucide-react";

import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";

import { useSections } from "../hooks/useSections";
import type { SectionDto } from "../../infrastructure/dto/SectionDto";

import {
    sectionSchema,
    type SectionFormData
} from "../../domain/validators/sectionSchema";

export default function SectionPage() {
    const {
        sections,
        create,
        update,
        remove
    } = useSections();

    const [editingId, setEditingId] =
        useState<number | null>(null);

    const {
        register,
        handleSubmit,
        reset,
        setValue,
        formState: { errors }
    } = useForm<SectionFormData>({
        resolver: zodResolver(sectionSchema)
    });

    const onSubmit = async (
        data: SectionFormData
    ) => {
        try {
            if (editingId !== null) {
                await update(
                    editingId,
                    data.name
                );
            } else {
                await create(
                    data.name
                );
            }

            reset();
            setEditingId(null);
        } catch (error) {
            console.error(error);
        }
    };

    const handleEdit = (
        section: SectionDto
    ) => {
        setEditingId(section.id);

        setValue(
            "name",
            section.name
        );
    };

    const handleDelete = async (
        id: number
    ) => {
        if (
            !window.confirm(
                "Delete this section?"
            )
        ) {
            return;
        }

        try {
            await remove(id);
        } catch (error) {
            console.error(error);
        }
    };

    const handleCancel = () => {
        reset();

        setEditingId(null);
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
                        {editingId !== null
                            ? "Update Section"
                            : "Add New Section"}
                    </h2>
                </div>

                <form
                    onSubmit={handleSubmit(
                        onSubmit
                    )}
                    className="flex flex-col gap-4 md:flex-row"
                >
                    <div className="flex-1">
                        <input
                            {...register("name")}
                            placeholder="Enter section name"
                            className={`w-full rounded-xl border px-4 py-3 outline-none focus:border-blue-500 ${
                                errors.name
                                    ? "border-red-500"
                                    : "border-slate-300"
                            }`}
                        />

                        {errors.name && (
                            <p className="mt-2 text-sm text-red-600">
                                {
                                    errors.name
                                        .message
                                }
                            </p>
                        )}
                    </div>

                    <div className="flex gap-2">
                        <button
                            type="submit"
                            className="rounded-xl bg-blue-600 px-6 py-3 font-medium text-white transition hover:bg-blue-700"
                        >
                            {editingId !== null
                                ? "Update"
                                : "Save"}
                        </button>

                        {editingId !==
                            null && (
                            <button
                                type="button"
                                onClick={
                                    handleCancel
                                }
                                className="rounded-xl bg-slate-200 px-6 py-3 font-medium text-slate-700 transition hover:bg-slate-300"
                            >
                                Cancel
                            </button>
                        )}
                    </div>
                </form>
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
                            {sections.length ===
                            0 ? (
                                <tr>
                                    <td
                                        colSpan={
                                            3
                                        }
                                        className="py-10 text-center text-slate-500"
                                    >
                                        No sections
                                        found.
                                    </td>
                                </tr>
                            ) : (
                                sections.map(
                                    (
                                        section
                                    ) => (
                                        <tr
                                            key={
                                                section.id
                                            }
                                            className="border-t hover:bg-slate-50"
                                        >
                                            <td className="px-6 py-4">
                                                {
                                                    section.id
                                                }
                                            </td>

                                            <td className="px-6 py-4 font-medium">
                                                {
                                                    section.name
                                                }
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
                                                        <Pencil
                                                            size={
                                                                16
                                                            }
                                                        />
                                                    </button>

                                                    <button
                                                        onClick={() =>
                                                            handleDelete(
                                                                section.id
                                                            )
                                                        }
                                                        className="rounded-lg bg-red-500 p-2 text-white hover:bg-red-600"
                                                    >
                                                        <Trash2
                                                            size={
                                                                16
                                                            }
                                                        />
                                                    </button>
                                                </div>
                                            </td>
                                        </tr>
                                    )
                                )
                            )}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}
