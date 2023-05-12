import React, { useState, useEffect } from "react";
import { FileForm } from "../../../components/FileForm/FileForm";
import { useForm } from "react-hook-form";
import { TestPointJson } from "../../../ModelTypes";

export const UploadJson = () => {
  const {
    reset,
    control,
    watch,
    formState: { errors },
    handleSubmit,
    setValue,
  } = useForm<TestPointJson>({
    defaultValues: {},
  });

  return (
    <>
      <div>
        <FileForm control={control} name="file" />
      </div>
    </>
  );
};
