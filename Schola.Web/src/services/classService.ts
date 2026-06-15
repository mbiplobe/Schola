import api from "../api/axios";

export type ClassPayload = Record<string, unknown>;

export const getClasses = () =>
    api.get("/classes");

export const createClass = (data: ClassPayload) =>
    api.post("/classes", data);

export const updateClass = (id: number, data: ClassPayload) =>
    api.put(`/classes/${id}`, data);