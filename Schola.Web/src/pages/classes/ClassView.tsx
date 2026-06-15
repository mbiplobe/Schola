import { useEffect, useState } from "react";
import ClassForm from "../../components/class/ClassForm";
import ClassTable from "../../components/class/ClassTable";
import {
    createClass,
    getClasses,
    updateClass
} from "../../services/classService";

export default function ClassView() {
    const [classes, setClasses] = useState([]);
    const [form, setForm] = useState({
        id: 0,
        name: "",
        description: ""
    });

    useEffect(() => {
        loadData();
    }, []);

    const loadData = async () => {
        const res = await getClasses();
        setClasses(res.data);
    };

    const save = async () => {
        if (form.id === 0) {
            await createClass(form);
        } else {
            await updateClass(
                form.id,
                form
            );
        }

        setForm({
            id: 0,
            name: "",
            description: ""
        });

        loadData();
    };

    return (
        <>
            <h2>Class View</h2>

            <ClassForm
                form={form}
                setForm={setForm}
                save={save}
            />

            <hr />

            <ClassTable
                data={classes}
                edit={setForm}
            />
        </>
    );
}