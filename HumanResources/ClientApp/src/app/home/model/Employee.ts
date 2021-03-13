import { Role } from "./Role";

export interface Employee {
    id: number;
    name: string;
    contractTypeName: string;
    hourlySalary: number;
    monthlySalary: number;
    role: Role;
    annualSalary: number;
  }