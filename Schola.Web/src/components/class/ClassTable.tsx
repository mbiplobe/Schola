import { ClassModel } from "../../models/ClassModel";

interface Props {
    data: ClassModel[];
    edit: (item: ClassModel) => void;
}

export default function ClassTable({
    data,
    edit
}: Props) {
    return (
        <table>
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Name</th>
                    <th>Description</th>
                    <th>Action</th>
                </tr>
            </thead>

            <tbody>
                {data.map((item) => (
                    <tr key={item.id}>
                        <td>{item.id}</td>
                        <td>{item.name}</td>
                        <td>{item.description}</td>
                        <td>
                            <button
                                onClick={() =>
                                    edit(item)
                                }
                            >
                                Edit
                            </button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
}