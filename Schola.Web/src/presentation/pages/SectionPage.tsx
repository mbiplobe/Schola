import { useSections } from "../hooks/useSections";

export default function SectionPage() {
    const { sections } = useSections();

    return (
        <tbody>
            <tr>
                <th>Id</th>
                <th>Name</th>
            </tr>
            {sections.map((section) => (
                <tr key={section.id}>
                    <td>{section.id}</td>
                    <td>{section.name}</td>
                </tr>
            ))}
        </tbody>
    );
}