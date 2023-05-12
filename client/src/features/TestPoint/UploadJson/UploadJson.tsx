import React, { useState, useEffect } from "react";
import { FileForm } from "../../../components/FileForm/FileForm";
import { useForm } from "react-hook-form";
import { TestPointJson } from "../../../ModelTypes";
import { File } from "../../../components/File/File";
import axios from "axios";

export const UploadJson = () => {
  const uploadUrl = "https://dev.digitando-server.com.hr/api/Data/UploadFile";
  const [file, setFile] = useState<FileList>();

  const uploadJsonAsync = async (model: TestPointJson) => {
    if (model.file === undefined) {
      return [];
    }

    console.log(model.file);

    const formData = new FormData();
    formData.append("files", model.file);
    // for (let i = 0; i < files.length; i++) {
    //   formData.append("files", files[i]);
    // }

    console.log(formData, model, "formData model");

    return await axios
      .post<any>(uploadUrl, formData, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      })
      .then((x) => x.data);
  };

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

  // useEffect(() => {
  //   const file = watch("file");
  //   setFile(file);
  // }, [watch("file")]);

  // useEffect(() => {
  //   if (file !== undefined) {
  //     console.log(file, "file");
  //     uploadJsonAsync({ file })
  //       .then((x) => {
  //         console.log(x, "x");
  //       })
  //       .catch((err) => {
  //         console.log(err, "err");
  //       });
  //   }
  // }, [file]);

  return (
    <>
      <div>
        {/* <FileForm control={control} name="file" /> */}
        <File
          name="file"
          onChange={(file) => {
            console.log(file, "file");
            uploadJsonAsync({ file: file as File }).then((x) => {
              console.log(x, "x");
            });
          }}
        />
      </div>
    </>
  );
};
