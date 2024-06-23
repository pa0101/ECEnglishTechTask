import { ReactNode } from "react";

interface DropdownProps<T> {
  items: T[];
  labelKey: keyof T;
  valueKey: keyof T;
  onSelect: (value: T) => void;
  defaultOption?: string;
}

export const Dropdown = <T,>({ items, labelKey, valueKey, onSelect, defaultOption }: DropdownProps<T>) => {
  return (
    <select onChange={(e) => onSelect(items.find(item => item[valueKey] === e.target.value)!)}>
      {defaultOption && (
        <option>{defaultOption}</option>
      )}
      {items.map((item, index) => (
        <option key={index} value={String(item[valueKey])}>
          {item[labelKey] as unknown as ReactNode}
        </option>
      ))}
    </select>
  );
};