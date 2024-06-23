import { ReactNode } from 'react';

interface DropdownProps<T> {
  items: T[];
  labelKey: keyof T;
  valueKey: keyof T;
  onSelect: (value: T) => void;
  defaultOption?: string;
  selectedValue?: string | number;
}

export const Dropdown = <T,>({ items, labelKey, valueKey, onSelect, defaultOption, selectedValue }: DropdownProps<T>) => {
  return (
    <select
      value={selectedValue}
      onChange={(e) => {
        const selectedItem = items.find(item => String(item[valueKey]) === e.target.value);
        if (selectedItem) {
          onSelect(selectedItem);
        }
      }}
    >
      {defaultOption && <option value="">{defaultOption}</option>}
      {items.map((item, index) => (
        <option key={index} value={String(item[valueKey])}>
          {item[labelKey] as unknown as ReactNode}
        </option>
      ))}
    </select>
  );
};
