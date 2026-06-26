import { useEffect, useState } from "react";
import type { User } from "../../domain/entities/User";
import { UserRepository } from "../../infrastructure/repositories/UserRepository";
import { RegisterUser } from "../../domain/useCases/RegisterUser";

export function useUser(id: string) {
  const [user, setUser] = useState<User | null>(null);

  useEffect(() => {
    const load = async () => {
      const useCase = new RegisterUser(
        new UserRepository()
      );

      setUser(await useCase.execute(id));
    };

    load();
  }, [id]);

  return user;
}