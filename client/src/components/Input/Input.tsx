import React, { useState, useEffect } from "react";
import {
  Control,
  Controller,
  FieldValues,
  Path,
  ValidationRule,
} from "react-hook-form";

type Props<T extends FieldValues> = {
  placeholder?: string;
  type?: string;
  name: Path<T>;
  control?: Control<T, any> | undefined;
  label: string;
};

const Input = <T extends FieldValues>({
  placeholder,
  type,
  name,
  control,
  label,
}: Props<T>) => {
  return (
    <>
      <Controller
        control={control}
        name={name}
        render={({ field: { onChange, onBlur, value, ref } }) => (
          <div>
            <label htmlFor={name}>{label}</label>
            <input placeholder={placeholder} type={type} />
          </div>
        )}
      />
    </>
  );
};

export default Input;
