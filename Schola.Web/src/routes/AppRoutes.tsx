// routes/AppRoutes.tsx

import { Routes, Route } from "react-router-dom";
import RegisterPage from "../presentation/pages/RegisterPage";

export default function AppRoutes() {
  return (
    <Routes>
      <Route
        path="/register"
        element={<RegisterPage />}
      />
    </Routes>
  );
}