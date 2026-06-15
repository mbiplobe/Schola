interface Props {
    form: any;
    setForm: any;
    save: () => void;
}

export default function ClassForm({
    form,
    setForm,
    save
}: Props) {
    return (
        <>
            <input
                value={form.name}
                placeholder="Class Name"
                onChange={(e) =>
                    setForm({
                        ...form,
                        name: e.target.value
                    })
                }
            />

            <input
                value={form.description}
                placeholder="Description"
                onChange={(e) =>
                    setForm({
                        ...form,
                        description: e.target.value
                    })
                }
            />

            <button onClick={save}>
                {form.id === 0
                    ? "Save"
                    : "Update"}
            </button>
        </>
    );
}