import Modal from "antd/es/modal/Modal";
import { KebabRequest } from "../services/kebabs";
import { useEffect, useState } from "react";
import TextArea from "antd/es/input/TextArea";
import { Input } from "antd";

interface Props {
    mode: Mode;
    values: Kebab;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: KebabRequest) => void;
    handleUpdate: (id: string, request: KebabRequest) => void;
  }
  

export enum Mode {
    Create,
    Edit,
}

export const CreateUpdateKebab = ({
    mode,
    values,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate
} : Props) => {
    const [name, setName] = useState<string>("");
    const [description, setDescription] = useState<string>("");
    const [price, setPrice] = useState<number>(1);

    useEffect(() => {
            setName(values.name);
            setDescription(values.description);
            setPrice(values.price);
    }, [values]);

    const handleOnOk = async () => {
        const kebabRequest = { name, description, price };

        mode == Mode.Create
            ? handleCreate(kebabRequest)
            : handleUpdate(values.id, kebabRequest)
    }

    return (
        <Modal 
            title={
                mode === Mode.Create ? "Add a kebab" : "Edit a kebab"
        } 
        open={isModalOpen} 
        onOk={handleOnOk}
        onCancel={handleCancel}
        cancelText={"Cancel"}
    >
        <div className="kebab__modal">
            <input 
                className="kebab-input"
                style={{ color: 'rgba(0, 0, 0, 0.88)' }}
                value={name}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setName(e.target.value)}
                placeholder="Name"
            />
            <TextArea
                value={description}
                onChange={(e: React.ChangeEvent<HTMLTextAreaElement>) => setDescription(e.target.value)}
                autoSize={{ minRows: 3, maxRows: 3 }}
                placeholder="Description"
            />
            <Input
                value={price}
                onChange={(e: React.ChangeEvent<HTMLInputElement>) => setPrice(Number(e.target.value))}
                placeholder="Price"
            />
        </div>
        </Modal>
    )
};