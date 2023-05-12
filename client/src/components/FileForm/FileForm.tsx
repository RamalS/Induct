import React, { useState, useEffect } from "react";
import {
  Control,
  Controller,
  FieldValues,
  Path,
  ValidationRule,
} from "react-hook-form";
import { File } from "../File/File";
import "./FileForm.scss";

type Props<T extends FieldValues> = {
  name: Path<T>;
  control?: Control<T, any> | undefined;
  multiple?: boolean;
  rules?: {
    required?: boolean;
    maxLength?: number;
    minLength?: number;
    max?: number;
    min?: number;
    pattern?: ValidationRule<RegExp>;
  };
};

export const FileForm = <T extends FieldValues>({
  name,
  control,
  multiple,
  rules,
}: Props<T>) => {
  return (
    <React.Fragment>
      <div className="file-form-container">
        <Controller
          control={control}
          name={name}
          rules={rules}
          render={({ field: { onChange } }) => {
            return (
              <>
                <File
                  name={name}
                  onChange={(e) => {
                    onChange(e);
                  }}
                  multiple={multiple}
                />
              </>
            );
          }}
        />
      </div>
    </React.Fragment>
  );
};
