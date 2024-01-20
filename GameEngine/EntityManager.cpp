#include <algorithm>
#include <iostream>
#include "EntityManager.h"

//****************************
// Constructors / Destructor *
//****************************

EntityManager::EntityManager() : numEntities(0)
{

}

EntityManager::~EntityManager()
// Deletes all Entities in, and clears, entitiesToAdd, entities, and entityMap.
{
	for (Entity*& entity : entities)
	{
		delete entity;
	}

	for (Entity*& entity : entitiesToAdd)
	{
		delete entity;
	}

	for (std::pair<const std::string, std::vector<Entity*>>& pear : entityMap)
	{
		pear.second.clear();
	}

	entities.clear();
	entitiesToAdd.clear();
	entityMap.clear();
}

//************
// Functions *
//************

Entity* EntityManager::addEntity(const std::string& tag)
// Creates a new Entity, stores it in the vector entitiesToAdd until
// the entities vector and entityMap are currently not being iterated,
// in which the newly created Entity will then be moved to the entites 
// vector and the entityMap.
{
	Entity* entity = new Entity(tag, numEntities++);

	entitiesToAdd.push_back(entity);

	return entity;
}

std::vector<Entity*> EntityManager::getEntities() const 
// Returns a vector of all Entities.
{
	return entities;
}

std::vector<Entity*> EntityManager::getEntities(const std::string& tag) const
// Returns a vector of all Entites mapped with the specified tag.
{
	if (entityMap.find(tag) != entityMap.end())
		return entityMap.at(tag);

	return std::vector<Entity*>();
}

std::vector<Entity*> EntityManager::getEntitiesToAdd() const
// Returns a vector of all Entites in entitiesToAdd.
{
	return entitiesToAdd;
}

std::unordered_map<std::string, std::vector<Entity*>> EntityManager::getEntityMap() const
// Returns an unordered map of all Entities.
{
	return entityMap;
}

void EntityManager::printContents() const
// Prints the contents of the entitiesToAdd vector, entities vector, and entityMap.
{
	std::cout << "[entitiesToAdd] \n";

	int entitiesToAddSize = entitiesToAdd.size();

	if (!entitiesToAdd.empty())
	{
		for (int i = 0; i < entitiesToAddSize; ++i)
		{
			std::cout << '[' << i << "] Tag: " << entitiesToAdd[i]->getTag() << ", ID: " << entitiesToAdd[i]->getID() << '\n';
		}
	}
	else
	{
		std::cout << "(empty)" << '\n';
	}

	std::cout << "\n[entities]\n";

	if (!entities.empty())
	{
		for (int i = 0; i < numEntities; ++i)
		{
			std::cout << '[' << i << "] Tag: " << entities[i]->getTag() << ", ID: " << entities[i]->getID() << '\n';
		}
	}
	else
	{
		std::cout << "(empty)" << '\n';
	}

	std::cout << "\n[entityMap]";

	if (!entityMap.empty())
	{
		for (auto& pear : entityMap)
		{
			const std::vector<Entity*>& entitiesOfThisType = pear.second;
			int entitiesOfThisTypeSize = pear.second.size();

			std::cout << "\n    [" << pear.first << ']';

			for (int i = 0; i < entitiesOfThisTypeSize; ++i)
			{
				std::cout << "\n        [" << i << "] Tag: " << entitiesOfThisType[i]->getTag() << ", ID: " << entitiesOfThisType[i]->getID();
			}
		}
	}
	else
	{
		std::cout << "\n(empty)\n";
	}
}

void EntityManager::update()
// Moves all of the entities in the entitiesToAdd vector to the
// entities vector and the entityMap at the beginning of each frame.
// Entities that are marked as dead will be removed from the entities
// vector and entityMap.
{
	// Add the Entities from entitiesToAdd to entities and entityMap
	for (Entity*& entity : entitiesToAdd)
	{
		entities.push_back(entity);							
		entityMap[entity->getTag()].push_back(entity);		
	}

	entitiesToAdd.clear();

	// Delete dead Entities from entities
	for (Entity*& entity : entities)
	{
		if (!entity->isActive())
		{
			delete entity;
			entity = nullptr;
			--numEntities;
		}
	}

	// Erase all null Entity pointers from entities
	entities.erase(std::remove(entities.begin(), entities.end(), nullptr), entities.end());

	// Erase all null Entity pointers from entityMap
	for (std::pair<const std::string, std::vector<Entity*>>& pear : entityMap)	// for each pair<type, entities> in entityMap
	{
		std::vector<Entity*>& entitiesOfThisType = pear.second;					// for each Entity in current vector

		entitiesOfThisType.erase(std::remove(entitiesOfThisType.begin(), entitiesOfThisType.end(), nullptr), entitiesOfThisType.end()); // remove if Entity* is nullptr
	}
}

void EntityManager::test()
// Prints a sample test to the terminal that demonstrates the functionalities of this class.
{
	//**************
	// constructor *
	//**************
	
	EntityManager entityManager;

	//*******************************************
	// Verify the contents of the entityManager *
	//*******************************************

	std::cout << "created an empty entity manager...\n\n";

	entityManager.printContents();

	std::cout << "\n\n---------------------------------------------------\n\n";

	//*******************************************************************
	// addEntity function() - adds Entities to the entitiesToAdd vector *
	//*******************************************************************

	// add 10 'enemy' Entities
	for (int i = 0; i < 10; ++i)
	{
		entityManager.addEntity("enemy");
	}

	// add 5 'ally' Entities
	for (int i = 0; i < 5; ++i)
	{
		entityManager.addEntity("ally");
	}

	std::cout << "called addEntity(\"enemy\") 10 times...\n";
	std::cout << "called addEntity(\"ally\")  5 times...\n\n";

	entityManager.printContents();

	std::cout << "\n\n---------------------------------------------------\n\n";

	//************************************************************************************
	// update() - verify Entities are moved from entitiesToAdd to entities and entityMap *
	//************************************************************************************

	entityManager.update();

	std::cout << "called update()...\n\n";

	entityManager.printContents();
}