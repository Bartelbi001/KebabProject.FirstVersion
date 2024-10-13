export interface KebabRequest {
    name: string;
    description: string;
    price: number;
};

export const getAllKebabs = async () => {
    const response = await fetch("https://localhost:7298/Kebabs");

    return response.json();
};

export const createKebab = async (kebabRequest: KebabRequest) => {
    await fetch("https://localhost:7298/Kebabs", {
        method: "POST",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(kebabRequest),
    });
};

export const updateKebab = async (id: string, kebabRequest: KebabRequest) => {
    await fetch("https://localhost:7298/Kebabs/${id}", {
        method: "PUT",
        headers: {
            "content-type": "application/json",
        },
        body: JSON.stringify(kebabRequest),
    });
};

export const deleteKebab = async (id: string) => {
    await fetch("https://localhost:7298/Kebabs/${id}", {
        method: "DELETE",
    });
};