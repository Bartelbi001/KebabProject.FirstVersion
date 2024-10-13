"use client";

import Button from "antd/es/button/button";
import { Kebabs } from "../components/Kebabs";
import { useEffect, useState } from "react";
import { createKebab, deleteKebab, getAllKebabs, KebabRequest, updateKebab } from "../services/kebabs";
import Title from "antd/es/skeleton/Title";
import { CreateUpdateKebab, Mode } from "../components/CreateUpdateKebab";
import { request } from "http";

export default function KebabsPage(){
    const defaultValues = {
            name: "",
            description: "",
            price: 1,
    } as Kebab;

    const [values, setValues] = useState<Kebab>(defaultValues)

    const [kebabs, setKebabs] = useState<Kebab[]>([]);
    const [loading, setLoading] = useState(true);
    const [isModalOpen, setModalOpen] = useState(false);
    const [mode, setMode] = useState(Mode.Create);

    useEffect(() => {
        const getKebabs = async () => {
            const kebabs = await getAllKebabs();
            setLoading(false);
            setKebabs(kebabs);
        };
    
        getKebabs();
    }, []);
    
    const handleCreateKebab = async (request: KebabRequest) => {
        await createKebab(request);
        closeModal();
    
        const kebabs = await getAllKebabs();
        setKebabs(kebabs);
    }
    
    const handleUpdateKebab = async (id: string, request: KebabRequest) => {
        await updateKebab(id, request);
        closeModal();
    
        const kebabs = await getAllKebabs();
        setKebabs(kebabs);
    }
    
    const handleDeleteKebab = async (id: string) => {
        await deleteKebab(id);
    
        const kebabs = await getAllKebabs();
        setKebabs(kebabs);
    }    

    const openModal = () => {
        // setMode(Mode.Create);
        setModalOpen(true);
    }

    const closeModal = () => {
        setValues(defaultValues);
        setModalOpen(false);
    }

    const openEditModal = (kebab: Kebab) => {
        setMode(Mode.Edit);
        setValues(kebab);
        setModalOpen(true);
    }

     return (
        <div>
            <Button
                type="primary"
                style={{ marginTop: "30px"}}
                size="large"
                onClick={openModal}
            >
                Add a kebab
            </Button>

            <CreateUpdateKebab 
                mode={mode} 
                values={values} 
                isModalOpen={isModalOpen} 
                handleCreate={handleCreateKebab} 
                handleUpdate={handleUpdateKebab} 
                handleCancel={closeModal} 
            />

            {loading ? (
                <Title>Loading...</Title>
            ) : (
                <Kebabs 
                    kebabs={kebabs} 
                    handleOpen={openEditModal} 
                    handleDelete={handleDeleteKebab}
                />
            )}
        </div>
     )
}