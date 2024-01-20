#ifndef _ENTITYMANAGER_H
#define _ENTITYMANAGER_H

#include <string>
#include <unordered_map>
#include <vector>
#include "Entity.h"

class EntityManager
{
	//********************************************************
	// Factory class that automates the storage of Entities. *
	//********************************************************

public:

	//****************************
	// Constructors / Destructor *
	//****************************

	EntityManager();

	~EntityManager();
	// Deletes all Entities in, and clears, entitiesToAdd, entities, and entityMap.

	//************
	// Functions *
	//************

	Entity*	addEntity(const std::string& tag);
	// Creates a new Entity, stores it in the std::vector entitiesToAdd until
	// the entities vector and entityMap are currently not being iterated (to avoid iterator invalidation),
	// in which the newly created Entity will then be moved to the entites vector and the entityMap.
	
	std::vector<Entity*> getEntities() const;
	// Returns a vector of all Entities.

	std::vector<Entity*> getEntities(const std::string& tag) const;
	// Returns a vector of all Entites mapped with the specified tag.

	std::vector<Entity*> getEntitiesToAdd() const;
	// Returns a vector of all Entites in entitiesToAdd.

	std::unordered_map<std::string, std::vector<Entity*>> getEntityMap() const;
	// Returns an unordered map of all Entities.

	void printContents() const;
	// Prints the contents of the entitiesToAdd vector, entities vector, and entityMap.

	void update();
	// Moves all of the Entities in the entitiesToAdd vector to the
	// entities vector and the entityMap at the beginning of each frame.
	// Entities that are marked as dead will be removed from the entities
	// vector and entityMap.

	//*******
	// Test *
	//*******

	static void test();
	// Prints a sample test to the terminal that demonstrates the functionalities of this class.

private:

	//*******
	// Data *
	//*******

	std::unordered_map<std::string, std::vector<Entity*>> entityMap;	// organizes Entities by their tag or "type" (key = type, val = vect of enemies of that type)
	std::vector<Entity*>	entities;									// to store all Entities (excluding those in entitiesToAdd)
	std::vector<Entity*>	entitiesToAdd;								// a queue for Entities to be added to the next frame of the game
	int						numEntities;
};

#endif