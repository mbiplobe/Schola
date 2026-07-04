import { Routes, Route } from "react-router-dom";
import SectionPage from "../presentation/pages/SectionPage";

export default function AppRoutes() {
    return (
        <Routes>
            <Route
                path="/sections"
                element={<SectionPage />}
            />
        </Routes>
    );
}